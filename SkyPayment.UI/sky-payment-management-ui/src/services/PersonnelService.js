import {PersonnelRequests} from "./requests/personnel/PersonnelRequests";
import {string} from "prop-types";

class PersonnelService {
    constructor() {
        this.personnelRequests = new PersonnelRequests();
    }

    async createPersonnel(personnel =
                              {
                                  name: string,
                                  lastName: string,
                                  email: string,
                                  password: string,
                                  restaurantId: string,
                                  userName: string
                              }) {
        const response = await this.personnelRequests.createPersonnel(personnel);
        return response.data;
    }

    async getPersonnels(restaurantId) {
        let response;
        if (restaurantId == null) {
            response = await this.personnelRequests.getPersonnels();
        } else {
            response = await this.personnelRequests.getPersonnelsByRestaurant({restaurantId});
        }

        return response.data;
    }
}

export default PersonnelService;