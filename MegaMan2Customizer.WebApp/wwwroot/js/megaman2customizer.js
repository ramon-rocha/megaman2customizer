var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
function romFileOnChange() {
    return __awaiter(this, void 0, void 0, function* () {
        let romFileInput = document.getElementsByName("romFile")[0];
        let romFileNameInput = document.getElementsByName("romFileName")[0];
        let displayedNameSpan = document.getElementById("displayed-name");
        if (romFileInput.files.length == 0) {
            romFileNameInput.value = "";
            displayedNameSpan.innerText == "";
            return;
        }
        let fileName = romFileInput.files[0].name;
        romFileNameInput.value = fileName;
        displayedNameSpan.innerText = fileName;
        let formData = new FormData(document.getElementsByTagName("form")[0]);
        let response = yield fetch("romdata", {
            method: "POST",
            body: formData
        });
        let romDataContainer = document.getElementById("rom-data-container");
        romDataContainer.innerHTML = yield response.text();
    });
}
//# sourceMappingURL=megaman2customizer.js.map