using Manipulae.Domain.Entities;
using Manipulae.Domain.Interface.Video;
using Manipulae.Domain.Requests.Video;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulae.Infrastructure.DataAccess.Repositories.Video
{
    public class VideoRepository :
        IVideoReadRepository,
        IVideoWriteRepository,
        IVideoUpdateRepository,
        IVideoDeleteRepository
    {
        private readonly ManipulaeDbContext _dbContext;

        public VideoRepository(ManipulaeDbContext manipulaeDbContext)
        {
            _dbContext = manipulaeDbContext;
        }

        public async Task<VideoEntity?> GetByIdAsync(long id)
        {
            return await _dbContext.Videos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<VideoEntity>> Filter(VideoRequest request)
        {
            var query = _dbContext.Videos.AsQueryable();

            if (!string.IsNullOrEmpty(request.Titulo))
                query = query.Where(v => v.Titulo.Contains(request.Titulo));

            if (request.Duracao.HasValue)
                query = query.Where(v => v.Duracao == request.Duracao);

            if (!string.IsNullOrEmpty(request.Autor))
                query = query.Where(v => v.Autor.Contains(request.Autor));

            if (request.DataCriacao.HasValue)
                query = query.Where(v => v.DataCriacao > request.DataCriacao);

            if (!string.IsNullOrEmpty(request.q))
                query = query.Where(v => v.Titulo.Contains(request.q) || v.Descricao.Contains(request.q) || v.Canal.Contains(request.q));

            return await query.ToListAsync();
        }

        public async Task Add(VideoEntity video)
        {
            await _dbContext.Videos.AddAsync(video);
        }

        public async Task Delete(long id)
        {
            var result = await _dbContext.Videos.FindAsync(id);

            _dbContext
                .Videos
                .Remove(result!);
        }

        public void Update(VideoEntity entity)
        {
            _dbContext
                .Videos
                .Update(entity);
        }
    }
}
