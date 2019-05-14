using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Infrastructure.Extensions;
using TeduShop.Web.Models.Synchronize;

namespace TeduShop.Web.Controllers
{
    [RoutePrefix("api/syncLog")]
    public class SyncLogController :  ApiControllerBase
    {
        #region Initialize

        private ISyncLogService _syncLogService;

        public SyncLogController(IErrorService errorService, ISyncLogService syncLogService)
            : base(errorService)
        {
            this._syncLogService = syncLogService;
        }

        #endregion Initialize

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request,int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _syncLogService.GetAll();

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<SyncLog>, IEnumerable<SyncLogViewModel>>(model);

                var paginationSet = new PaginationSet<SyncLogViewModel>()
                {
                    Items = responseData,
                    PageIndex = page,
                    TotalRows = totalRow,
                    PageSize = pageSize
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, SyncLogViewModel syncLogViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newSyncLog = new SyncLog();
                    newSyncLog.UpdateSyncLog(syncLogViewModel);
                    newSyncLog.CreatedDate = DateTime.Now;
                    _syncLogService.Add(newSyncLog);
                    _syncLogService.Save();

                    var responseData = Mapper.Map<SyncLog, SyncLogViewModel>(newSyncLog);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

    }
}