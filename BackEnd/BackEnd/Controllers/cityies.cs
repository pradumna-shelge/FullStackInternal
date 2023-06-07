using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using BackEnd.RepoPattren.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cityies : ControllerBase
    {
        private readonly Icity _city;

        public cityies(Icity icity)
        {
            _city = icity;
        }


        [HttpGet("state")]

        public IActionResult Get()
        {
            var city = from x in _city.Get()
                       where x.StateId == null
                       select new
                       {
                           id = x.CityId,
                           name = x.CityName,
                       };

            if(city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpGet("{id}")]
        public IActionResult GetgetBy(int id)
        {
            var city = from x in _city.Get()
                       where x.StateId == id
                       select new
                       {
                           id = x.CityId,
                           name = x.CityName,
                       };

            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }


        //private const string AccessKey = "AKIA33GSIZ3RZDCIZDSK";
        //private const string SecretKey = "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";
        private const string BucketName = "aws-day1-practice4";
        private const string url = "";
        [HttpPost("ImageUrl")]


        public async Task<IActionResult> geturlAsync(
            IFormFile file)


        {


            if (file == null || file.Length <= 0)
            {
                return BadRequest("No file specified.");
            }
            var destKey = $"Images/{file.FileName.ToLower() + DateTime.Now.ToString()}";

            using (var client = new AmazonS3Client(Amazon.RegionEndpoint.APSouth1))
            {
                using (var transferUtility = new TransferUtility(client))
                {
                    var transferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = BucketName,
                        Key = destKey,
                        InputStream = file.OpenReadStream(),
                    };

                    await transferUtility.UploadAsync(transferUtilityRequest);
                }
            }
            var reg = RegionEndpoint.APSouth1;
            var url = $"https://{BucketName}.s3.{reg.SystemName}.amazonaws.com/{destKey}";
            var resp = new
            {
                url = url
            };

            return Ok(resp);
        }


    }
}
