using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    //[EnableCors(origins: "http://localhost:38730/", headers: "*", methods: "*")]
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public string Get()
        {
            return "sucess";
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }
        // POST: api/Default
        public async Task<string> Post()
        {
            try
            {
                //web api 获取项目根目录下指定的文件下
                var root = System.Web.Hosting.HostingEnvironment.MapPath("/Resource/Images");
                var provider = new MultipartFormDataStreamProvider(root);

                //文件已经上传  但是文件没有后缀名  需要给文件添加后缀名
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    //这里获取含有双引号'" '
                    string filename = file.Headers.ContentDisposition.FileName.Trim('"');
                    //获取对应文件后缀名
                    string fileExt = filename.Substring(filename.LastIndexOf('.'));

                    FileInfo fileinfo = new FileInfo(file.LocalFileName);
                    //fileinfo.Name 上传后的文件路径 此处不含后缀名 
                    //修改文件名 添加后缀名
                    string newFilename = fileinfo.Name + fileExt;
                    //最后保存文件路径
                    string saveUrl = Path.Combine(root, newFilename);
                    fileinfo.MoveTo(saveUrl);
                }
                return "success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
