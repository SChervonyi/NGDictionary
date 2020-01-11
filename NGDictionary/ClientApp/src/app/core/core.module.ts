import { NgModule } from '@angular/core';

import { NoAuthGuard } from '@core/guard/no-auth.guard';

@NgModule({
  providers: [
    NoAuthGuard,
  ]
})
export class CoreModule {
  constructor() {
  }
}
