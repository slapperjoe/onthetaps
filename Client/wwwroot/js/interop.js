globalThis.interop = {
   dotNet: null,
   deck: null,
   
   consoleLog: (textString) => {
      window.console.log(textString);
      return true;
   },
   hookDotNet: (dotNetObj) => {
      globalThis.interop.dotNet = dotNetObj;
   },
   RefreshImage: async (imageElementId, url) => {
      debugger;
      const image = document.getElementById(imageElementId);
      image.onload = () => {
         URL.revokeObjectURL(url);
      }
      image.src = url;
   },
   ShowLoadBox: (element) => {
      element.style.display = "block"
   },

   HideLoadBox: (element) => {
      element.style.display = "none"
   }
};

