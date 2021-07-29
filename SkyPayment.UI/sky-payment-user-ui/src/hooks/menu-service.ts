import {AxiosInstance} from "axios";
import {useAxiosApi} from "../contexts/api-axios-context";
import {MenuItemResponse, MenuResponseModel} from "../components/menu/interfaces";

class MenuService {
    private readonly _axiosApi: AxiosInstance;

    constructor(axiosApi: AxiosInstance) {
        this._axiosApi = axiosApi;
    }

    async getMenuList(restaurantId: string) {
        const response = await this._axiosApi.get(`menu/${restaurantId}`);
        return response.data;
    }

    async getMenuContent(restaurantId: string, menuId: string): Promise<MenuResponseModel> {
        const response = await this._axiosApi.get(`menu/${restaurantId}/${menuId}`);
        return response.data;
    }

    async getMenuItem(restaurantId: string, menuId: string, itemId: string): Promise<MenuItemResponse> {
        return {
            id: '1',
            price: 189.5,
            name: 'Piyaz',
            ingredients: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Pellentesque sit amet porttitor eget dolor morbi. Dolor magna eget est lorem ipsum. Fames ac',
            imageUrl: 'https://dynaimage.cdn.cnn.com/cnn/q_auto,w_900,c_fill,g_auto,h_506,ar_16:9/http%3A%2F%2Fcdn.cnn.com%2Fcnnnext%2Fdam%2Fassets%2F200401170445-01-best-turkish-foods-piyaz.jpg',
            productContents: [{type: 'vegan', displayName: 'Vegan'}, {
                type: 'gluten-free',
                displayName: 'Glutent Free'
            }],
        }
        const response = await this._axiosApi.get(`menu/${restaurantId}/${menuId}/${itemId}`);
        return response.data;
    }
}

export const useMenuService = () => {
    const axiosApi = useAxiosApi();
    const menuService = new MenuService(axiosApi);
    return menuService;
}

