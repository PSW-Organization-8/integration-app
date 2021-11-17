using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAPI.Dto;
using IntegrationAPI.Mapper;
using IntegrationClassLib.Parthership.Model;
using IntegrationClassLib.Parthership.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsAndNewsController : ControllerBase
    {
        private readonly IActionsAndNewsService actionsAndNewsService;

        public ActionsAndNewsController(IActionsAndNewsService actionsAndNewsService)
        {
            this.actionsAndNewsService = actionsAndNewsService;
        }

        [HttpGet]
        public List<News> GetAllActionsAndNews()
        {
            return actionsAndNewsService.GetAllActionsAndNews();
        }

        [HttpPut]
        [Route("approve")]
        public IActionResult ApproveNews(NewsDto newsDto, long id = 0)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            return Ok(actionsAndNewsService.ApproveNews(NewsMapper.NewsDtoToNews(newsDto)));
        }

        [HttpPut]
        [Route("unapprove")]
        public News UnApproveNews(NewsDto newsDto)
        {
            return actionsAndNewsService.UnapproveNews(NewsMapper.NewsDtoToNews(newsDto));
        }
    }
}
