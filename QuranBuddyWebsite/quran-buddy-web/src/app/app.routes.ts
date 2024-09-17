import { Routes } from '@angular/router';


export const routes: Routes = [
    //{ path: '**', redirectTo: 'chapters' },
    {
        path: 'chapters',
        loadComponent: () => import('./chapter-list/chapter-list.component').then(c => c.ChapterListComponent)           
    },
    {
        path: 'chapter/:id',
        loadComponent: () => import('./chapter-view/chapter-view.component').then(c => c.ChapterViewComponent)           
    },
    /*{
        path: 'flashcardsets',
        loadComponent: () => import('./chapter/chapter-view/chapter-view.component').then(c => c.ChapterViewComponent)           
    },
    {
        path: 'create-flashcardset',
        loadComponent: () => import('./chapter/chapter-view/chapter-view.component').then(c => c.ChapterViewComponent)           
    },
    {
        path: 'flashcardsets',
        loadComponent: () => import('./chapter/chapter-view/chapter-view.component').then(c => c.ChapterViewComponent)           
    },*/
];
