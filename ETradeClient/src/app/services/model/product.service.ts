import { Injectable } from '@angular/core';
import {HttpClientService} from "../common/http-client.service";
import {ProductCreate} from "../../contracts/product_create";
import {ProductList} from "../../contracts/product_list";
import {ProductListWithTotalCount} from "../../contracts/product_list_with_total_count";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private httpClientService: HttpClientService) { }

  createProduct(product: ProductCreate,successCallBack : () => void) {
    this.httpClientService.post({ controller: "product" }, product).subscribe(result => { successCallBack() })
  }

  async getProduct(page, size, successCallCack? : () => void, errorCallBack? : () => void){

    // @ts-ignore
    var promise = new Promise<ProductListWithTotalCount>((resolve,reject) =>{
      this.httpClientService.get<ProductListWithTotalCount>({controller:"product",queryString:`page=${page}&size=${size}`}).subscribe((result) => {
        resolve(result)
      })
    })

    promise.then(value => {successCallCack()}).catch(error =>{errorCallBack()})
    return await promise
  }
}
