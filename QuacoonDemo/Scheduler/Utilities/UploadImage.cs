using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*using System.IO;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;*/

namespace Quacoon.Utilities
{
    public static class UploadImage
    {
        public static bool UploadFiles(HttpPostedFileBase fileP, string bucketName, string subBucketName, string key)
        {
            try
            {
                String finalBucketName = String.Empty;

                if (subBucketName == "" || subBucketName == null)
                {
                    finalBucketName = bucketName;
                }
                else
                {
                    finalBucketName = bucketName + @"/" + subBucketName;
                }
                /*TransferUtility fileTransferUtility = new
                    TransferUtility(new AmazonS3Client(Amazon.RegionEndpoint.USWest1));*/

              /*  AmazonS3Client s3Client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);

                PutObjectRequest request = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    Key = key,
                    InputStream = fileP.InputStream,
                    ContentType = fileP.ContentType,
                    CannedACL = S3CannedACL.PublicRead
                };

                s3Client.PutObject(request);*/

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            /*catch (AmazonS3Exception s3Exception)
            {
                Console.WriteLine(s3Exception.Message,
                                  s3Exception.InnerException);
                return false;
            }*/
        }
    }
}
