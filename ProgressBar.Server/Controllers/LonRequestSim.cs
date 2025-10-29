using Microsoft.AspNetCore.Mvc;
using ProgressBar.Server.Utilities;
using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProgressBar.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LonRequestSim : ControllerBase
    {
        // GET api/<LonRequestSim>/5
        [HttpGet("{id}")]
        public async Task Get(int id)
        {
            ProgressBarStreamer streamer = new ProgressBarStreamer(this.ControllerContext);

            switch (id)
            {
                case 0:
                {
                    for (int progress = 0; progress <= 100; progress += 5)
                    {
                        await streamer.StreamProgress(progress);
                            //simulate some extensive work
                            await Task.Delay(500);
                    }
                    break;
                }
                case 1:
                {
                    for (int progress = 0; progress < 100; progress += 5)
                    {
                            for (int progress_2 = 0; progress_2 <= 100; progress_2 += 10)
                            {
                                await streamer.StreamProgress(progress, progress_2);
                                //simulate some extensive work
                                await Task.Delay(100);
                            }

                    }
                    break;
                }
                case 2:
                {
                    for (int progress = 0; progress < 95; progress += 5)
                    {
                        await streamer.StreamProgress(progress);
                            //simulate some extensive work
                        await Task.Delay(200);
                    }
                        try
                        {
                            var products = JsonSerializer.Deserialize<dynamic>(
                                            System.IO.File.ReadAllText("Mockdata/products.json")
                                            );
                            await streamer.StreamProgress(100, products);
                        }
                        catch (Exception e) {
                            Console.WriteLine(e);
                        }

                        break;
                }
                default:
                {
                    break;
                }
            }
        }
    }
}
