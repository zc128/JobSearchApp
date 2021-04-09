// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//This is the function for save/unsave job details to Cache
if ('caches' in window) {
    let offlineBtn = $('#saveForOffline');

    if (offlineBtn) {
        let isCached = false;

        offlineBtn.on('click', async () => {
            let cache = await caches.open('offline-job-posts')
                .then(async (cache) => {
                    let isNotCached = await cache.match(window.location.href);

                    let cacheMech = () => {
                        cache.add(window.location.href);
                    }

                    if (isNotCached) {
                        offlineBtn.val('Save to Caches');
                        cacheMech = () => {
                            cache.delete(window.location.href);
                        }
                    } else {
                        offlineBtn.val('Remove from Caches');
                    }
                    cacheMech();
                })
        });

        (async function () {
            await caches.open('offline-job-posts')
                .then(async (cache) => {
                    cache.match(window.location.href).then((isCached) => {
                        if (isCached) {
                            offlineBtn.val('Remove from Cache');
                        } else {
                            offlineBtn.val('Save to Caches');
                        }
                    });
                });
        })();
    }

    offlineBtn.removeAttr('hidden');
}

//This is the function for sharing job postings
function share() {
    if (!("share" in navigator)) {
        alert('Web Share API not supported.');
        return;
    }

    navigator.share({
        title: 'This is a Job Posting',
        text: 'Please take a look at this Job Posting',
        url: 'https://JobSearchApp.com/'
    })
        .then(() => console.log('Successful share'))
        .catch(error => console.log('Error sharing:', error));
}










//if ('clipboard' in navigator) {
//    let canWriteClipboard = false;
//    navigator.permissions.query({ name: 'clipboard-read' }).then((perms) => {
//        canWriteClipboard = perms.state;

//        if (canWriteClipboard === "granted") {
//            $("#copyToClipboard").on('click', () => { navigator.clipboard.writeText(window.location.href); })
//        } else if (canWriteClipboard === "prompt") {
//            $("#copyToClipboard").on('click', () => { $("#clipboardPerms").show(); })
//        } else {
//            return;
//        }

//        $("#copyToClipboard").removeAttr('hidden');
//    });
//}
  //document.querySelector("#saveForOffline").removeAttribute('hidden');