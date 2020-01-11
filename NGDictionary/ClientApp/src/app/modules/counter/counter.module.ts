import { CounterComponent } from '@modules/counter/page/counter/counter.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CounterRoutingModule } from './counter-routing.module';


@NgModule({
  declarations: [CounterComponent],
  imports: [
    CommonModule,
    CounterRoutingModule,
  ]
})
export class CounterModule { }
