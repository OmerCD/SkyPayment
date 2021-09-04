import React, {useEffect} from 'react';
import {useAxiosApi} from "../../contexts/api-axios-context";

function Dashboard(props: DashboardPropType) {
    const api = useAxiosApi().baseApi;
    useEffect(() => {
        api.get("RoleTest/manager").then(x => {
            console.log(x);
        })
    }, [])
    return (
        <div></div>
    );
}

export default Dashboard;

export interface DashboardPropType {

}
