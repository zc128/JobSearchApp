//const cacheName = 'v1';

function swInstall(event) {
    // Perform install steps
    console.info('Service Worker Installing...');
  //event.waitUntil(
  //    caches.open('v1').then((cache) => {
  //        return cache.addAll([
  //            './',
  //            './css/site.css',
  //            './js/site.js',
  //            './favicon.ico',
  //            './home/privacy'
  //        ]);
  //    })
  //);
  //console.info('Finished Caching Website...')
}
self.addEventListener('install', swInstall);
//NetworkOnly
/*self.addEventListener('fetch', function (event) {
    event.respondWith(
        fetch(event.request).then(function (networkResponse) {
            return networkResponse
        })
    )
})*/

//Cache only
/*self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request).then(function (cacheResponse) {
            return cacheResponse
        })
    )
})*/

//NewWork First
/*self.addEventListener('fetch', function (event) {
    event.respondWith(
        fetch(event.request)
            .then(function (networkResponse) {
                return networkResponse
            }).catch(function () {
                return caches.match(event.request)
            })
    )
})*/

//Cache First
//self.addEventListener('fetch', function (event)
//    event.respondWit
//        caches.match(event.request).then(function (cacheResponse)
//            if (cacheResponse)
//                return cacheRespons
//            } else
//                return fetch(event.request).then((netResp) => netRes
//           
//        
//   
//})