if (window.location.pathname.includes('playground')) { 
    document.getElementById('app').innerHTML = '<div class="loader">Loading...</div>';
    window.Blazor.start();
}