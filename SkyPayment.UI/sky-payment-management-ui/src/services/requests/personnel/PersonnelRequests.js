import {BaseRequests} from "../BaseRequests";

export class PersonnelRequests extends BaseRequests {
    constructor() {
        super();
        this.baseController = 'personnel';
    }

    async createPersonnel(personnel) {
        return await this.axios.post('register/personnel', personnel);
    }

    async getPersonnelsByRestaurant({restaurantId}) {
        return await this.axios.get(this.baseController, {param: {restaurantId}});
    }
    async getPersonnels(){
        return await this.axios.get(this.baseController);
    }
}