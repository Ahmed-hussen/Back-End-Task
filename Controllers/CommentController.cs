using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlogPost_API.Data;
using BlogPost_API.Dtos.Post;
using BlogPost_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost_API.Controllers
{  [ApiController]
    [Route("[controller]/[Action]")]

    public class CommentController: ControllerBase
    {
                 private readonly IBlogRepo _repo;
        private readonly IMapper _mapper;

        public CommentController(IBlogRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }




        [HttpPost("{id}")]
        public async Task<IActionResult> Create(int id,CommentForAddDto model){
            var getAllPosts=await _repo.getPostId(id);
            var comment=_mapper.Map<Comment>(model);
            comment.PostId=getAllPosts.Id;
             _repo.Add(comment);
           await  _repo.SaveAll();
           return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadOnlyComment( int id){
             var getAllComments=await _repo.getCommentId(id);
            var comment= _mapper.Map<CommentForDetails>(getAllComments);
        
           return Ok(comment);
        }

           [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,CommentForAddDto model){

            var getAllcomments=await _repo.getCommentId(id);
            var comment=_mapper.Map(model,getAllcomments);
            await _repo.SaveAll();
           return Ok(comment);
        }


       [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){

            var getAllcomments=await _repo.getCommentId(id);
   
            await _repo.Delete(getAllcomments);
           return Ok();
        }
    }
}