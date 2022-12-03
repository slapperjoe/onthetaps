using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBeerData.Shared;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace OnTheTaps.Client.Services
{
   public class BrowserService
   {

      private readonly IJSRuntime _js;

      public BrowserService(IJSRuntime js)
      {
         _js = js;
      }    

      public string TapJson(int tapNo)
      {
         return $"https://cs1c08048ede1dax4ddbx836.blob.core.windows.net/bigbeercontainer/{tapNo + 1}.json?m={DateTime.Now.ToBinary()}";
		}

      public string TapImage(int tapNo)
      {
         return $"https://cs1c08048ede1dax4ddbx836.blob.core.windows.net/bigbeercontainer/{tapNo}.png?m={DateTime.Now.ToBinary()}";
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

}
