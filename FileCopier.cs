using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeFileCopier
{
    public static class FileCopier
    {
        static async Task TryCopy( string targetPath, int bufferSize )
        {
            string sourceFile = Console.ReadLine( )?.Trim( );
            string destinationFile = " ";
            int sizeMB = 0;

            CreateTestFile( sourceFile, sizeMB );

            Console.WriteLine( "파일 복사 시작" );

            var stopwatch = Stopwatch.StartNew( );
            await CopyFile( sourceFile, bufferSize );
            stopwatch.Stop( );

            Console.WriteLine( $"\n복사 완료됨\n소요 시간: {stopwatch.Elapsed.TotalSeconds:F2}초" );

            double fileSizeGB = new FileInfo( destinationFile ).Length / ( 1024.0 * 1024.0 * 1024.0 );
            double speed = fileSizeGB / stopwatch.Elapsed.TotalSeconds;
            Console.WriteLine( $"평균 복사 속도: {speed:F2} GB/s" );
        }

        static void CreateTestFile( string path, int sizeMB )
        {
            byte[] buffer = new byte[1024 * 1024];
            Random rnd = new Random( );

            using var fs = new FileStream( path, FileMode.Create, FileAccess.Write );
            for ( int i = 0; i < sizeMB; i++ )
            {
                rnd.NextBytes( buffer );
                fs.Write( buffer, 0, buffer.Length );
            }
        }

        static async Task CopyFile( string sourcePath, int bufferSize )
        {
            string destinationPath;
            const double progressReportInterval = 1.0;

            try
            {
                using var sourceStream = new FileStream(
                    sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize,
                    FileOptions.Asynchronous | FileOptions.SequentialScan );

                // 복사본 경로로 바꿔야 함
                using var destinationStream = new FileStream(
                    sourcePath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize,
                    FileOptions.Asynchronous | FileOptions.SequentialScan );

                byte[] buffer = new byte[bufferSize];
                long totalRead = 0;
                long totalSize = sourceStream.Length;
                double lastReportedProgress = 0;

                int read;
                while ( ( read = await sourceStream.ReadAsync( buffer, 0, buffer.Length ) ) > 0 )
                {
                    await destinationStream.WriteAsync( buffer, 0, read );
                    totalRead += read;

                    double progress = ( double ) totalRead / totalSize * 100;
                    if ( progress - lastReportedProgress >= progressReportInterval || totalRead == totalSize )
                    {
                        Console.Write( $"\r진행률 : {progress:F2}%" );
                        lastReportedProgress = progress;
                    }
                }
            }
            catch ( IOException ex )
            {
                Console.WriteLine( $"\n파일 복사 중 오류 발생: {ex.Message}" );
            }
        }
    }
}