import { FetchDataComponent } from '@modules/fetch-data/page/fetch-data/fetch-data.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FetchDataRoutingModule } from './fetch-data-routing.module';


@NgModule({
  declarations: [
    FetchDataComponent
  ],
  imports: [
    CommonModule,
    FetchDataRoutingModule
  ]
})
export class FetchDataModule { }
