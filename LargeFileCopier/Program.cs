using System.Diagnostics;

class Program
{
    static async Task Main( )
    {
        Console.WriteLine( "=== 대용량 파일 복사 처리기 ===" );

        Console.Write( "복사할 테스트 파일 이름: " );
        string sourceFile = Console.ReadLine( )?.Trim( );
        if ( string.IsNullOrEmpty( sourceFile ) ) sourceFile = "testFile.dat";

        Console.Write( "테스트 파일 크기 (MB 단위): " );
        if ( !int.TryParse( Console.ReadLine( ), out int sizeMB ) || sizeMB <= 0 )
        {
            Console.WriteLine( "입력 오류 -> 1024MB로 설정" );
            sizeMB = 1024;
        }

        Console.Write( "반환될 복사본 파일 이름: " );
        string destinationFile = Console.ReadLine( )?.Trim( );
        if ( string.IsNullOrEmpty( destinationFile ) ) destinationFile = "copyfile.dat";

        if ( !File.Exists( sourceFile ) )
        {
            Console.WriteLine( $"{sizeMB}MB 크기의 테스트 파일 생성" );
            CreateTestFile( sourceFile, sizeMB );
        }

        Console.WriteLine( "파일 복사 시작" );

        var stopwatch = Stopwatch.StartNew( );
        await CopyFile( sourceFile, destinationFile );
        stopwatch.Stop( );

        Console.WriteLine( $"\n복사 완료됨\n소요 시간: {stopwatch.Elapsed.TotalSeconds:F2}초" );

        double fileSizeGB = new FileInfo( destinationFile ).Length / ( 1024.0 * 1024.0 * 1024.0 );
        double speed = fileSizeGB / stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine( $"평균 복사 속도: {speed:F2} GB/s" );
    }

    static void CreateTestFile( string path, int sizeMB )
    {
        byte[] buffer = new byte[ 1024 * 1024 ];
        Random rnd = new Random( );

        using var fs = new FileStream( path, FileMode.Create, FileAccess.Write );
        for ( int i = 0; i < sizeMB; i++ )
        {
            rnd.NextBytes( buffer );
            fs.Write( buffer, 0, buffer.Length );
        }
    }

    static async Task CopyFile( string sourcePath, string destinationPath )
    {
        const int bufferSize = 4 * 1024 * 1024;
        const double progressReportInterval = 1.0;

        try
        {
            using var sourceStream = new FileStream(
                sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize,
                FileOptions.Asynchronous | FileOptions.SequentialScan );

            using var destinationStream = new FileStream(
                destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize,
                FileOptions.Asynchronous | FileOptions.SequentialScan );

            byte[] buffer = new byte[ bufferSize ];
            long totalRead = 0;
            long totalSize = sourceStream.Length;
            double lastReportedProgress = 0;

            int read;
            while ( ( read = await sourceStream.ReadAsync( buffer, 0, buffer.Length ) ) > 0 )
            {
                await destinationStream.WriteAsync( buffer, 0, read );
                totalRead += read;

                double progress = ( double )totalRead / totalSize * 100;
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