import {AuthRequests} from "./requests/auth/AuthRequests";

class AuthenticationService {
    constructor(authContext) {
        this.authRequestManager = new AuthRequests();
        this.authContext = authContext;
    }

    async login(userName, password) {
        const result = await this.authRequestManager.login(userName, password);
        if (result?.status === 200) {
            localStorage.setItem('token', JSON.stringify(result.data.data));
            this.authContext.setToken(result.data.data.token);
        }
        return result;

    }

    async register(registerInfo){
        const result = await this.authRequestManager.register(registerInfo);
        return result;
    }

    async testManagementToken(){
        return await this.authRequestManager.testManagementAuthentication();
    }
    async testPersonnelToken() {
        return await this.authRequestManager.testPersonnelAuthentication();
    }
    async testCustomerToken(){
        return await this.authRequestManager.testCustomerAuthentication();
    }

    getToken() {
        if (!this.authContext) {
            return null;
        }
        if (this.authContext.token) {
            return this.authContext.token;
        }
        const savedTokenString = localStorage.getItem('token');
        const savedToken = JSON.parse(savedTokenString)?.token;
        this.authContext.setToken(savedToken);
        if (savedTokenString === null) {
            return null;
        }
        return savedToken;
    }

    logout() {
        localStorage.removeItem('token');
        this.authContext.setToken(null);
    }
}

export default AuthenticationService;
