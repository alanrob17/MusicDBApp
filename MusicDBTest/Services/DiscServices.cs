using MusicDAL.Data;
using MusicDAL.Models;
using MusicDAL.Models.Dtos;
using MusicDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicDBTest.Services
{
    public class DiscServices : IDiscServices
    {
        private readonly DiscRepository _dr;

        public DiscServices()
        {
            var db = new DataAccess();
            _dr = new DiscRepository(db);
        }

        public async Task RunDiscServices()
        {
            // await GetAllDiscsAsync();
            // await GetAllDiscLengthsAsync();
            // await GetDiscByIdAsync(2956);
            // await GetLongDiscsAsync();
            await GetSingleTrackDiscsAsync();
        }


        public async Task GetAllDiscsAsync()
        {
            var discs = await _dr.GetAllDiscsAsync();

            foreach (var disc in discs)
            {
                var name = disc.Name ?? string.Empty;
                var subTitle = disc.SubTitle ?? string.Empty;    
                Console.WriteLine($"Did: {disc.DiscId} -- Rid: {disc.RecordId} -- {name} {subTitle} - Dno: {disc.DiscNumber} - {disc.Length} - {disc.Duration}\n");
            }
        }

        public async Task GetAllDiscLengthsAsync()
        {
            var discs =  await _dr.GetAllDiscLengthsAsync();

            foreach (var disc in discs)
            {
                var discName = disc.DiscName ?? string.Empty;
                Console.WriteLine($"Artist: {disc.ArtistName}, Year: {disc.Recorded} - Title: {disc.RecordName}, Field: {disc.Field}, Disc No: {disc.DiscNumber}, Length: {disc.Length}");
            }
        }

        public async Task GetDiscByIdAsync(int discId)
        {
            var disc = await _dr.GetDiscByIdAsync(discId);

            var name = disc.Name ?? string.Empty;
            var subTitle = disc.SubTitle ?? string.Empty;

            Console.WriteLine($"Did: {disc.DiscId} -- Rid: {disc.RecordId} -- {name} {subTitle} - Dno: {disc.DiscNumber} - {disc.Length} - {disc.Duration}\n");
        }

        public async Task GetLongDiscsAsync()
        {
            var discs = await _dr.GetLongDiscsAsync();

            foreach (var disc in discs)
            {
                Console.WriteLine(
                    $"Artist: {disc.ArtistName}, Year: {disc.Recorded} - Title: {disc.RecordName}, Field: {disc.Field}, Disc No: {disc.DiscNumber}, Length: {disc.Length}");
            }
        }

        public async Task GetSingleTrackDiscsAsync()
        {
            var discs = await _dr.GetSingleTrackDiscsAsync();

            foreach (var disc in discs)
            {
                Console.WriteLine(
                    $"Artist: {disc.ArtistName}, Year: {disc.Recorded} - Title: {disc.RecordName}, Field: {disc.Field}, Disc No: {disc.DiscNumber}, Length: {disc.Length}");
            }
        }
    }
}
