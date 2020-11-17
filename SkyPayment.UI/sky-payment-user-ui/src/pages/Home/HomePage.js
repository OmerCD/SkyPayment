import React from "react";
import AuthenticationService from "../../services/AuthenticationService";

function Homepage() {
    const authService = new AuthenticationService();
    const testAuth = () => {
        authService.testManagementToken().then(result => {
            console.log("Auth Token Management Test :", result);
        });
        authService.testPersonnelToken().then(result => {
            console.log("Auth Token Personnel Test :", result);
        });
        authService.testCustomerToken().then(result => {
            console.log("Auth Token Customer Test :", result);
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
