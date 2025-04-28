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
        private static string GetDestinationPath( string path )
        {
            int index = path.LastIndexOf( '.' );
            return path.Substring( 0, index );
        }

        static async Task TryCopy( string targetPath, int bufferSize )
        {
            string destinationFile = GetDestinationPath( targetPath );
            Form1.AddOutputText( $"\n복사에 사용할 버퍼 사이즈를 {bufferSize} MB로 설정합니다." );
            Form1.AddOutputText( $"\n복사를 시작합니다.\n" );

            var stopwatch = Stopwatch.StartNew( );
            await CopyFile( targetPath, bufferSize );
            stopwatch.Stop( );
            Form1.AddOutputText( $"\n복사가 완료되었습니다.\n소요 시간: {stopwatch.Elapsed.TotalSeconds:F2}초" );

            double fileSizeGB = new FileInfo( destinationFile ).Length / ( 1024.0 * 1024.0 * 1024.0 );
            double speed = fileSizeGB / stopwatch.Elapsed.TotalSeconds;
            Form1.AddOutputText( $"\n평균 복사 속도: {speed:F2} GB/s" );
        }

        public static async Task CreateTestFile( string path, int bufferSize )
        {
            Form1.AddOutputText( "10GB 용량의 임시 파일을 바탕 화면 경로에 생성합니다." );
            byte[] buffer = new byte[1024 * 1024];
            Random rnd = new Random( );
            int sizeMB = 10240;

            using var fs = new FileStream( path, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true );
            for ( int i = 0; i < sizeMB; i++ )
            {
                rnd.NextBytes( buffer );
                await fs.WriteAsync( buffer, 0, buffer.Length );
            }

            Form1.AddOutputText( "\n임시 파일 생성이 완료되었습니다." );
            await fs.FlushAsync( );
            await TryCopy( path, bufferSize );
        }

        static async Task CopyFile( string sourcePath, int bufferSize )
        {
            string destinationPath = GetDestinationPath( sourcePath );
            const double progressReportInterval = 1.0;

            try
            {
                using var sourceStream = new FileStream(
                    sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize,
                    FileOptions.Asynchronous | FileOptions.SequentialScan );

                using var destinationStream = new FileStream(
                    destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize,
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
                        Form1.AddOutputText( $"\r진행률 : {progress:F2}%" );
                        lastReportedProgress = progress;
                    }
                }
            }
            catch ( IOException ex )
            {
                Form1.AddOutputText( $"\n파일 복사 중 오류 발생: {ex.Message}" );
            }
        }
    }
}