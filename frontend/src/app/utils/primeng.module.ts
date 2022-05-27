import { NgModule } from '@angular/core';

import { RippleModule } from 'primeng/ripple';
import { TooltipModule } from 'primeng/tooltip';
import { TreeTableModule } from 'primeng/treetable';
import { FileUploadModule } from 'primeng/fileupload';
import { TableModule } from 'primeng/table';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { ButtonModule } from 'primeng/button';
import { MessageModule } from 'primeng/message';
import { MessagesModule } from 'primeng/messages';
import { ToolbarModule } from 'primeng/toolbar';
import { InputTextModule } from 'primeng/inputtext';
import { MenubarModule } from 'primeng/menubar';
import {DropdownModule} from 'primeng/dropdown';

@NgModule({
  declarations: [],
  imports: [
    TreeTableModule,
    RippleModule,
    FileUploadModule,
    TableModule,
    BreadcrumbModule,
    AutoCompleteModule,
    InputTextModule,
    ButtonModule,
    MessageModule,
    MessagesModule,
    ToolbarModule,
    TooltipModule,
    MenubarModule,
    DropdownModule
    
    
  ],
  exports: [
    TreeTableModule,
    RippleModule,
    FileUploadModule,
    TableModule,
    BreadcrumbModule,
    AutoCompleteModule,
    InputTextModule,
    ButtonModule,
    MessageModule,
    MessagesModule,
    ToolbarModule,
    TooltipModule,
    MenubarModule,
    DropdownModule
  ],
})
export class PrimeNGModule {}
