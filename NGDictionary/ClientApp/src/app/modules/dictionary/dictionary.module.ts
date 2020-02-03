import { SharedModule } from '@shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DictionaryListComponent } from './page/dictionary-list/dictionary-list.component';
import { DictionaryItemComponent } from './page/dictionary-list/dictionary-item/dictionary-item.component';
import { WordListComponent } from './page/word-list/word-list.component';
import { WordItemComponent } from './page/word-list/word-item/word-item.component';
import { DictionaryRoutingModule } from './dictionary-router.module';


@NgModule({
  declarations: [DictionaryListComponent, DictionaryItemComponent, WordListComponent, WordItemComponent],
  imports: [
    CommonModule,
    DictionaryRoutingModule,
    SharedModule
  ]
})
export class DictionaryModule { }
