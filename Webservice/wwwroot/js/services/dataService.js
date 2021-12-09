define([], () => {
    let getCharsFromTitle = (id, callback) => {
        fetch("api/title" + id + "CharactersFromTitle")
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        getCharsFromTitle
    }
});