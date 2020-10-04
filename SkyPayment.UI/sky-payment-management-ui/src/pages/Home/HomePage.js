import React from "react";
import AuthenticationService from "../../services/AuthenticationService";

function Homepage() {
    const authService = new AuthenticationService();
    const testAuth = () => {
        authService.testToken().then(result => {
            console.log("Auth Token Test :", result);
        })
    }
    return (
        <div>
            <h1>Welcome</h1>
            <button onClick={testAuth}>Test</button>
        </div>
    )
}

export default Homepage;
