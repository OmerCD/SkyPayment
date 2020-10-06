import {BaseRequests} from "../BaseRequests";

export default class RestaurantRequests extends BaseRequests{
    constructor() {
        super();
        this.baseController = 'restaurant';
    }
    getUserRestaurants(){
        return this.axios.get(this.baseController);
    }
}
