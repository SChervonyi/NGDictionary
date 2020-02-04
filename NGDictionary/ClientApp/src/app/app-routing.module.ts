import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContentLayoutComponent } from './layout/content-layout/content-layout.component';
import { NoAuthGuard } from '@core/guard/no-auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/auth/login',
    pathMatch: 'full'
  },
  {
    path: '',
    component: ContentLayoutComponent,
    canActivate: [NoAuthGuard], // Should be replaced with actual auth guard
    children: [
      {
        path: 'auth',
        loadChildren: () =>
          import('@modules/auth/auth.module').then(m => m.AuthModule)
      },
      {
        path: 'home',
        loadChildren: () =>
          import('@modules/home/home.module').then(m => m.HomeModule)
      },
      {
        path: 'counter',
        loadChildren: () =>
          import('@modules/counter/counter.module').then(m => m.CounterModule)
      },
      {
        path: 'fetch-data',
        loadChildren: () =>
          import('@modules/fetch-data/fetch-data.module').then(m => m.FetchDataModule)
      }
    ]
  }
  // { path: '**', component: PageNotFoundComponent }, //TODO: Implement
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }
