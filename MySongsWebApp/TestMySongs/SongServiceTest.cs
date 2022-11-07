using Microsoft.Extensions.Logging;
using Moq;
using MySongsWebApp.Services;

namespace TestMySongs
{
    public class SongServiceTest
    {
        [Fact]
        public void GetSongs_is_not_null()
        {
            var logger = new Mock<ILogger<SongService>>();
            var sut = new SongService(logger.Object);
            var songs = sut.GetSongs();

            Assert.True(songs is not null, "Expected songs not null");
        }

        [Fact]
        public void GetSongs_has_at_least_one_item()
        {
            var logger = new Mock<ILogger<SongService>>();
            var sut = new SongService(logger.Object);
            var songs = sut.GetSongs();

            Assert.True(songs.Count() > 0, "Expected songs to be grater than one");
        }

    }
}