using System;
using System.Collections.Generic;
using System.Linq;
using SmartStore.Core.Domain.Media;
using SmartStore.Data.Utilities;
using SmartStore.Services.Media;
using SmartStore.AndMore.Domain;
using SmartStore.AndMore.Data;

namespace SmartStore.AndMore.Media
{
    public class SmartStoreAndMoreAlbumProvider : IAlbumProvider, IMediaTrackDetector
    {
        public const string Name = "SmartStoreAndMore";

        private readonly SmartStoreAndMoreObjectContext _dbContext;

        public SmartStoreAndMoreAlbumProvider(SmartStoreAndMoreObjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MediaAlbum> GetAlbums()
        {
            yield return new MediaAlbum { Name = Name, ResKey = "Plugins.FriendlyName.SmartStore.SmartStoreAndMore", CanDetectTracks = true };
        }

        public AlbumDisplayHint GetDisplayHint(MediaAlbum album)
        {
            return null;
        }

        public void ConfigureTracks(string albumName, TrackedMediaPropertyTable table)
        {
            table.Register<SmartStoreAndMoreRecord>(x => x.PictureId);
        }

        public IEnumerable<MediaTrack> DetectAllTracks(string albumName)
        {
            var ctx = _dbContext;
            var name = nameof(SmartStoreAndMoreRecord);
            var p = new FastPager<SmartStoreAndMoreRecord>(ctx.Set<SmartStoreAndMoreRecord>().AsNoTracking().Where(x => x.PictureId > 0));
            while (p.ReadNextPage(x => new { x.Id, x.PictureId }, x => x.Id, out var list))
            {
                foreach (var x in list)
                {
                    yield return new MediaTrack { EntityId = x.Id, EntityName = name, MediaFileId = x.PictureId, Property = nameof(x.PictureId) };
                }
            }
        }
    }
}