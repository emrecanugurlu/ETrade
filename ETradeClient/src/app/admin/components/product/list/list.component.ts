import {Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {ProductService} from "../../../../services/model/product.service";
import {ProductList} from "../../../../contracts/product_list";
import {MatPaginator} from "@angular/material/paginator";
import {ProductListWithTotalCount} from "../../../../contracts/product_list_with_total_count";

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit{
  displayedColumns: string[] = ['name', 'description', 'stock', 'price','createdDate','updatedDate'];
  dataSource = null
  @ViewChild(MatPaginator) paginator : MatPaginator

  constructor(private productService: ProductService) {

  }

  async getProducts(){
    var productListWithTotalCount : ProductListWithTotalCount = await this.productService.getProduct(this.paginator ?this.paginator.pageIndex : 0,this.paginator ? this.paginator.pageSize:5,() => {console.log("İşlem" +
      " Başarılı");() => {console.log("İşlem Başarısız")}})
    this.dataSource = new MatTableDataSource(productListWithTotalCount.products)
    this.paginator.length = productListWithTotalCount.totalCount
  }

  async ngOnInit() {
    this.getProducts()
  }

  clickPage(){
    this.getProducts()
  }

}
