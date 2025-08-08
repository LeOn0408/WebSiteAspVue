// i18n.ts
import { createI18n } from 'vue-i18n'
import ru from './locales/ru.json';
import en from './locales/en.json';

const saved = localStorage.getItem('userLocale') as 'ru' | 'en' | null
const browser = navigator.language.split('-')[0] as 'ru' | 'en'
const initial = saved ?? (browser === 'ru' ? 'ru' : 'en')

export const i18n = createI18n({
    legacy: false,            // для Composition API
    globalInjection: true,    
    locale: initial,
    fallbackLocale: 'en',
    messages: { ru, en },
})
