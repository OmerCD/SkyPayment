export interface IMenuListProps {
    menus: IMenuListItem[]
}

export interface IMenuListItem {
    id: string;
    name: string;
    onSelected: (id: string) => void;
}

export interface MenuResponseModel {
    name: string;
    items: MenuItemResponse[];
    managementUserId: string;
    menuId:string;
}

export interface MenuItemResponse {
    id: string;
    name: string;
    price: number;
    ingredients: string;
    productContents: ProductContent[];
    imageUrl: string;
}

export interface ProductContent {
    type:string,
    displayName:string
}

// export enum ProductContent {
//     IsVegan = 1,
//     IsDiabetic = 2,
//     IsGlutenFree = 4,
//     IsVegetarian = 8
// }
