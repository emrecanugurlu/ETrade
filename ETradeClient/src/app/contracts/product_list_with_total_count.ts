import {ProductCreate} from "./product_create";
import {ProductList} from "./product_list";

export class ProductListWithTotalCount{
  totalCount : number
  products : ProductList[]
}
