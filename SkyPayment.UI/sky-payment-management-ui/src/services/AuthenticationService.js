import {AuthRequests} from "./requests/auth/AuthRequests";
import {useAuth} from "../context/AuthContext";

class AuthenticationService {
    constructor(authContext) {
        this.authRequestManager = new AuthRequests();
        this.authContext = authContext;
    }

    async login(userName, password) {
        const result = await this.authRequestManager.login(userName, password);
        console.log(result);
        if (result.status === 200) {
            localStorage.setItem('token', JSON.stringify(result.data));
            this.authContext.setToken(result.data.token);
        }
        return result;

    }

    async testToken() {
        return await this.authRequestManager.testAuthentication()
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
