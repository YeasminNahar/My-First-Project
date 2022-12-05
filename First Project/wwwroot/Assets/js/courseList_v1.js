Vue.component('vue-pagination', paginationTawsif);

new Vue({
    el: '#main-container',
    data: {

        courses: {
            total: 0,
            per_page: 2,
            from: 1,
            to: 0,
            current_page: 1
        },
        searchInput: '',
        categories: [],
        selectedCategory: 0,

        loaders:{
            listLoader: false,
            searching: false,
        },
    },
    methods:{
        getCourses(reset = false){

            this.loaders.listLoader = true;

            let route;

            if(reset){
                this.courses.current_page = 1;
            }

            if(this.searchInput == ''){
                route = routerConfig.courseList + '?&category_id='+ this.selectedCategory +'&page=' + this.courses.current_page;
            }else{
                this.selectedCategory = 0;
                route = routerConfig.courseList + '?&search_input='+ this.searchInput +'&page=' + this.courses.current_page;
            }

            this.$http.get(route).then((response)=>{
                this.courses = response.data.data.courses;
                this.loaders.listLoader = false;
            });
        },

        getStyleObj(color, image){
            if(image){
                return {
                    backgroundImage: 'url(' + image + ')',
                    backgroundSize: 'cover',
                    backgroundRepeat: 'no-repeat',
                    backgroundPosition: 'center center'
                }
            }else{
                return {
                    backgroundColor: color
                }
            }
        },

        getBgClass(){
            let colorClass = [
                'bg-gd-fruit-op',
                'bg-gd-lake-op',
                'bg-gd-sublime-op',
                'bg-danger',
                'bg-xeco'
            ];

            let length = colorClass.length;
            return colorClass[Math.floor(Math.random() * ((length-1) - 0 + 1)) + 0];
        },
        getCategories(){
            var route = routerConfig.categoryList;
            this.$http.get(route).then((response)=>{
                this.categories = response.data.data.categories;
            });
        }
    },
    mounted(){
        // Vue.http.headers.common['X-CSRF-TOKEN'] = document.getElementById('_token').getAttribute('content');
        this.getCategories();
        this.getCourses();
    }
});
