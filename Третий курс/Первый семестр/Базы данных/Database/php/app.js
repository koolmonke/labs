const host = window.location.host;

const update_values = (url) => {
    const request = async () => {
        const json = await fetch(url).then(response => response.json());
        for (const jsonKey in json) {
            if (json.hasOwnProperty(jsonKey) && document.getElementById(jsonKey) !== null) {
                document.getElementById(jsonKey).value = json[jsonKey];
            }
        }
    }
    return request();
};