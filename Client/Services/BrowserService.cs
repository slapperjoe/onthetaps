using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBeerData.Shared;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace Client.Services
{
   public class BrowserService
   {

      public DataState state { get; set; } = default!;

      private readonly IJSRuntime _js;

      public BrowserService(IJSRuntime js)
      {
         _js = js;
      }

      public async Task<BrowserDimension> GetDimensions()
      {
         return await _js.InvokeAsync<BrowserDimension>("interop.getDimensions");
      }

      public async Task<BrowserDimension> GetRenderArea()
      {
         return await _js.InvokeAsync<BrowserDimension>("interop.getRenderArea");
      }

      public async Task<bool> ConsoleLog(string logContent)
      {
         return await _js.InvokeAsync<bool>("interop.consoleLog", new[] { logContent });
      }

      public async Task<bool> RefreshImage(string imageFile)
      {
         await _js.InvokeAsync<dynamic>("interop.RefreshImage", imageFile + DateTime.Now.ToUniversalTime());
         return true;
      }

      public async Task ShowLoadBox(ElementReference element)
      {
         await _js.InvokeVoidAsync("interop.ShowLoadBox", element);
      }

      public async Task HideLoadBox(ElementReference element)
      {
         await _js.InvokeVoidAsync("interop.HideLoadBox", element);
      }

   }

   public class BrowserDimension
   {
      public int Width { get; set; }
      public int Height { get; set; }
   }
}
