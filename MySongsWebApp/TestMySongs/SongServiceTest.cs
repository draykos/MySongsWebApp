using Microsoft.Extensions.Logging;
using Moq;
using MySongs.BLL.Services;
using MySongs.DAL;

namespace TestMySongs
{
    public class SongServiceTest
    {
        [Fact]
        public void GetSongs_is_not_null()
        {
            var logger = new Mock<ILogger<SongService>>();
            var context = new Mock<MySongsContext>();
            var sut = new SongService(logger.Object, context.Object);
            var songs = sut.GetSongs();

            Assert.True(songs is not null, "Expected songs not null");
        }

        [Fact]
        public void GetSongs_has_at_least_one_item()
        {
            var logger = new Mock<ILogger<SongService>>();
            var context = new Mock<MySongsContext>();
            var sut = new SongService(logger.Object, context.Object);
            var songs = sut.GetSongs();

            Assert.True(songs.Count() > 0, "Expected songs to be grater than one");
        }

    }
}