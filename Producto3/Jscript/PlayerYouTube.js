// Genera un número aleatorio entre 0 y 8
var x = Math.floor(Math.random() * 9);

// Creamos un arreglo de strings con los IDs de los videos
let videoIds = ["N5PvmgZWKEI", "u8ad98ztTKc", "4QEW0DHWIlg",
    "2HYx8aItmXc", "WUkR1uh1hXE", "Rw-_NOsDkW8", "Y3V76QUVcm8",
    "CcFRpc1hfSI", "2zHpbpjUUY4", "1glXQNjR1RA"];

// Este código carga el código API del reproductor Iframe de forma asíncrona
var tag = document.createElement('script');
tag.src = "https://www.youtube.com/iframe_api";
var firstScriptTag = document.getElementsByTagName('script')[0];
firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

// Esta función crea un <iframe> (y un reproductor de YouTube) después de descargar el código API
var player;

function onYouTubeIframeAPIReady() {
    player = new YT.Player('player', {
        height: '360',
        width: '640',
        videoId: videoIds[x],
        events: {
            'onReady': onPlayerReady,
            'onStateChange': onPlayerStateChange
        }
    });
}

// La API llama a esta función cuando el reproductor de video está listo
function onPlayerReady(event) {
    event.target.playVideo();
}

// La API llama a esta función cuando el estado del reproductor cambia
var done = false;
function onPlayerStateChange(event) {
    if (event.data == YT.PlayerState.PLAYING && !done) {
        setTimeout(stopVideo, 6000);
        done = true;
    }
}

// Función para detener el video
function stopVideo() {
    player.stopVideo();
}
