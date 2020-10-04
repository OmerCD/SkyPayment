import {useAppSettings} from "../../context/AppSettingsContext";
import {useRequest} from "../../context/RequestContext";

export class BaseRequests {
    constructor() {
        this.baseAddress = useAppSettings().apiAddress;
        this.axios = useRequest();
    }

}
