import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DictionaryListComponent } from './page/dictionary-list/dictionary-list.component';


const routes: Routes = [
    {
        path: '',
        component: DictionaryListComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DictionaryRoutingModule { }
