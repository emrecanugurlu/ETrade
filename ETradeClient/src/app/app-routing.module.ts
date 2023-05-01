import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent as AdminLayout } from './admin/layout/layout.component';
import { HomeComponent } from './ui/components/home/home.component';
import { LayoutComponent as UiLayout } from './ui/layout/layout.component';

const routes: Routes = [
  {
    path: "", component: UiLayout, children: [
      { path: "", loadChildren: () => import("./ui/components/home/home.module").then(m => m.HomeModule) },
      { path: "basket", loadChildren: () => import("./ui/components/basket/basket.module").then(m => m.BasketModule) },
      { path: "product", loadChildren: () => import("./ui/components/product/product.module").then(m => m.ProductModule) },
    ]
  },

  {
    path: "admin", component: AdminLayout, children: [
      { path: "", loadChildren: () => import("./admin/components/dashboard/dashboard.module").then(m => m.DashboardModule) },
      { path: "customer", loadChildren: () => import("./admin/components/customer/customer.module").then(m => m.CustomerModule) },
      { path: "order", loadChildren: () => import("./admin/components/order/order.module").then(m => m.OrderModule) },
      { path: "product", loadChildren: () => import("./admin/components/product/product.module").then(m => m.ProductModule) },

    ]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
