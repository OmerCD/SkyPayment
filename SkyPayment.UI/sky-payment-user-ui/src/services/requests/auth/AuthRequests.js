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
    async register(registerInfo){
        const response = await axios.post(this.baseAddress+'register',registerInfo);
        return response;
    }
    async testManagementAuthentication(){
        const response = await this.axios.get('login/test/management');
        return response.status === 200;
    }
    async testPersonnelAuthentication(){
        const response = await this.axios.get('login/test/personnel');
        return response.status === 200;
    }
}
