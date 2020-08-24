import axios from "axios";

export default class RyM_Api {
    constructor() {
        this.urlGetOneCharacter = 'https://rickandmortyapi.com/api/character/';
    }

    GetRandomRemoteCharacter(i) {
        let character = this.generateRandom(i);
        let urlCharacter = this.urlGetOneCharacter + character;

        return axios.get(urlCharacter);
    };

    generateRandom(i) {
        return Math.ceil(Math.random() * i);
    };
}