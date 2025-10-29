using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProgressBar.Server.Utilities
{
    public class ProgressBarStreamer       
    {
        private ControllerContext ControllerContext { get; set; }
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public ProgressBarStreamer(ControllerContext controllerContext)
        {
            ControllerContext = controllerContext;
            ControllerContext.HttpContext.Response.ContentType = "text/event-stream";
            ControllerContext.HttpContext.Response.Headers["Cache-Control"] = "no-cache";
        }

        public async Task StreamProgress(int progress)
        {
            await _semaphore.WaitAsync();
            try
            {
                var payload = JsonSerializer.Serialize(new { progress });
                await ControllerContext.HttpContext.Response.WriteAsync(payload);
                await ControllerContext.HttpContext.Response.Body.FlushAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task StreamProgress(int progress, dynamic data)
        {
            await _semaphore.WaitAsync();
            try
            {
                var payload = JsonSerializer.Serialize(new
                {
                    progress,
                    data
                });
                await ControllerContext.HttpContext.Response.WriteAsync(payload);
                await ControllerContext.HttpContext.Response.Body.FlushAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task StreamProgress(int progress, int progress_2)
        {
            await _semaphore.WaitAsync();
            try
            {
                var payload = JsonSerializer.Serialize(new
                {
                    progress,
                    progress_2
                });
                await ControllerContext.HttpContext.Response.WriteAsync(payload);
                await ControllerContext.HttpContext.Response.Body.FlushAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public async Task StreamProgress(int progress, int progress_2, dynamic data)
        {
            await _semaphore.WaitAsync();
            try
            {
                var payload = JsonSerializer.Serialize(new
                {
                    progress,
                    progress_2,
                    data
                });
                await ControllerContext.HttpContext.Response.WriteAsync(payload);
                await ControllerContext.HttpContext.Response.Body.FlushAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
