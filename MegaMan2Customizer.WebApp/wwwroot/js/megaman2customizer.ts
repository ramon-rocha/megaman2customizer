async function romFileOnChange() {
    let romFileInput = document.getElementsByName("romFile")[0] as HTMLInputElement;
    let romFileNameInput = document.getElementsByName("romFileName")[0] as HTMLInputElement;
    let displayedNameSpan = document.getElementById("displayed-name") as HTMLSpanElement;
    if (romFileInput.files.length == 0) {
        romFileNameInput.value = "";
        displayedNameSpan.innerText == "";
        return;
    }
    let fileName = romFileInput.files[0].name;
    romFileNameInput.value = fileName;
    displayedNameSpan.innerText = fileName;

    let formData = new FormData(document.getElementsByTagName("form")[0]);
    let response = await fetch("romdata", {
        method: "POST",
        body: formData
    });

    let romDataContainer = document.getElementById("rom-data-container");
    romDataContainer.innerHTML = await response.text();
}