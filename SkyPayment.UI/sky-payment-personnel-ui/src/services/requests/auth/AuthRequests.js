import axios from 'axios'
import {BaseRequests} from "../BaseRequests";

export class AuthRequests extends BaseRequests{
    constructor() {
        super();
    }
    async login(userName,password){
        const response = await axios.post(this.baseAddress+'login',{userName,password});
        return response;
    }
    async testAuthentication(){
        const response = await this.axios.get('login/test');
        return response.status === 200;
    }
}
