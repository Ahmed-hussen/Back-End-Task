using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlogPost_API.Data;
using BlogPost_API.Dtos.Post;
using BlogPost_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost_API.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]

    public class PostController : ControllerBase
    {
        private readonly IBlogRepo _repo;
        private readonly IMapper _mapper;

        public PostController(IBlogRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostForAddDto model)
        {
            var post = _mapper.Map<Post>(model);
            _repo.Add(post);
            await _repo.SaveAll();
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Read(PostForListDto model)
        {
            var getAllPosts = await _repo.getAllPosts();
            var post = _mapper.Map<IEnumerable<PostForListDto>>(getAllPosts);
            return Ok(post);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ReadOnlyPost(int id)
        {
            var getPost = await _repo.getPostId(id);
            var post = _mapper.Map<PostForDetails>(getPost);

            return Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PostForAddDto model)
        {

            var getAllPosts = await _repo.getPostId(id);
            var post = _mapper.Map(model, getAllPosts);
            await _repo.SaveAll();
            return Ok(post);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var getAllPosts = await _repo.getPostId(id);

            await _repo.Delete(getAllPosts);
            return Ok();
        }
    }
}