using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SendEmail.Views
{
    public partial class ProjectDetails : ContentPage
    {
        public ProjectDetails(String name)
        {
            InitializeComponent();
            //switch (Device.RuntimePlatform)
            //{
            //    case Device.Android:
            //        NavigationPage.SetHasNavigationBar(this, false);
            //        break;
            //    default:
            //        NavigationPage.SetHasNavigationBar(this, true);
            //        break;
            //}
            GetProjectDetailByName(name);
        }

        public void GetProjectDetailByName(string name) {
            String projectName ="";
            String details = "";
            String source = "HimalayanTrust.png";
            switch (name){
                case "Airport":
                    source = "Airport.png";
                    projectName = "Hillary-Tenzing Airport";
                    details = "Lukla airport is the gateway to the Everest region for visitors and the second busiest airport in Nepal. It is often described as one of the most dangerous airstrips in the world. \n\nEd Hillary built the airstrip, with the help of the local people, in 1964. The aim was to transport in the construction materials to build the hospital in Khunde.\n\nIt took a team of more than 100 local people two weeks to clear the site. A huge piece of timber was dragged back and forth to level the field, followed by two days of Sherpa dancing (fuelled by vast quantities of chang - Sherpa beer) to compact it further.\n\nThe airstrip proved to be one of the most transformative construction projects the region has ever seen. \n\nLukla airport is now the second busiest airport in Nepal.";
                    break;
                case "KhumjungSchool":
                    source = "KhumjungSchool.png";
                    projectName = "Khumjung school";
                    details = "In 1960 Ed asked his Sherpa friends: ‘If there were one thing we could do for your village, what would it be?’ They said: 'Our children have eyes but cannot see. We would like to open their eyes by building a school in our village.'  \nIn 1961, Khumjung Primary School became Ed’s first school building project in Nepal. Ed Hillary hoped that education could help the Sherpa people improve their health and agriculture. \nFollowing the earthquake in 2015, the Himalayan Trust built 5 new classrooms at Khumjung school to replace classrooms damaged in the quake. The original aluminium schoolroom first built by Ed is now flanked by the new earthquake-strengthened classroom blocks.";
                    break;
                case "LuklaDrinkingWater":
                    source = "LuklaDrinkingWater.png";
                    projectName = "Lukla Drinking Water Project";
                    details = "The drinking water in Lukla lodges flows from a water system designed and built thanks to a collaboration between the local community and the Himalayan Trust. It was completed in October 2014. Prior to that there was a mishmash of leaky pipes and intermittent water supply for homes and lodges, which made life difficult for inhabitants and trekkers alike. ‘The impact of the water system in Lukla has been huge,’ say’s the local committee member Lakpa Thersing Sherpa. ‘Now everyone has 24-hour running water, this especially helps the women in the village. Before they had to walk long distances just to fetch water.’ \nThe Lukla drinking water project pipes safe water to homes and businesses benefitting more than 3,000 people. The water reservoir is located about a hundred metres above the town (on the right as you pass through Lukla). This project included installation of fire hydrants throughout the town which you can see as you stroll down the main street. The risk of fire is real as most houses are linked together like terrace houses and wood, kerosene and gas are used for cooking. A large fire in Lukla in 19xx killed xx and damaged a row of buildings, raising awareness of the dangers and the importance of taking fire prevention very seriously. The Himalayan Trust funded the water supply system, fire-fighting system and the training for 30 villagers and 60 local school children in fire safety and use of fire hydrants in Lukla. The water supply system in Lukla is a great model for other Khumbu villages to emulate. All water use by residents, businesses and lodges is recorded and charged via a metering system according to volume of use. This fee covers the operation and maintenance of the system.";
                    break;
                case "KundeHospital":
                    source = "KundeHospital.png";
                    projectName = "Kunde Hospital";
                    details = "The Kunde hospital was built in 1966 by Sir Ed Hillary and the friends and volunteers he persuaded to help him. From 1966 until 2002, Sir Ed recruited volunteer doctors, mostly from New Zealand and Canada to help run the hospital.\n\nIn 2002, Dr Kami became the first Sherpa doctor to take over the full management of the hospital. Today, the hospital is fully staffed by Nepali medical professionals and funded by the Sir Edmund Hillary Foundation of Canada.";
                    break;
                case "ChaurikharkaSchool":
                    source = "ChaurikharkaSchool.png";
                    projectName = "Chaurikharka school";
                    details = "Chaurikharka School was as good as destroyed completely during the earthquakes in 2015. Thanks to Himalayan Trust New Zealand and its supporters, the school has been completely rebuilt. The building has been constructed using steel framing, which is unusual in this area. Using steel provides earthquake strengthening and allows for larger classroom sizes to accommodate larger numbers of students.";
                    break;
                case "MuseyDrinkingWater":
                    source = "MuseyDrinkingWater.png";
                    projectName = "Musey Drinking Water Proejct";
                    details = "Himalayan Trust supporters helped the community of Musey build a seismic-resistant water system to replace the old water tanks that were destroyed in the 2015 earthquakes. The new water system was completed in early 2019 and includes:\n-Two water reservoirs with a total capacity of 45,000 litres\n-Four fire hydrants to protect homes from fire\n-A sand filter to make sure water is kept clean and safe from water borne disease \n-Pipes to deliver water directly to homes\n-Enough water to grow vegetables not only for families to eat, but also to sell and earn an income.";
                    break;
                case "ThameSchool":
                    source = "ThameSchool.png";
                    projectName = "Thame School";
                    details = "Thame school is one of 60 across the region that the Himalayan Trust supports with vital equipment, resources and training for teachers.\n\nThe Himalayan Trust also built the new earthquake-strengthened classroom blocks.\n\nFollowing the devastating earthquakes in 2015, the Himalayan Trust developed its biggest ever school building project. With funding from the New Zealand public, we built 150 earthquake-strengthened classroom blocks at 36 schools across the Everest region to replace those damaged and destroyed in the earthquakes.\nThame students are some of over 7000 children that are now able to study in safe, strong classrooms. And their families and communities will benefit from these facilities for decades to come.";
                    break;
                case "ShreeHimalayanPrimarySchool":
                    source = "ShreeHimalayanPrimarySchool.png";
                    projectName = "Shree Himalayan Primary School, Namche";
                    details = "Shree Himalaya School in Namche is one of 60 across the region that the Himalayan Trust supports with vital equipment, resources and training for teachers. \n\nThe Himalayan Trust and our local partner, Action for Nepal, are currently working with the staff, students and community at the school to improve the way literacy skills are taught and learned in the early years.";
                    break;
                case "MonjoSchool":
                    source = "MonjoSchool.png";
                    projectName = "Monjo school";
                    details = "Monjo school is one of 60 across the region that the Himalayan Trust supports with vital equipment, resources and training for teachers.\n\nThe Himalayan Trust also built the new earthquake-strengthened classroom block.\n\nFollowing the devastating earthquakes in 2015, the Himalayan Trust developed its biggest ever school building project. With funding from the New Zealand public, we built 150 earthquake-strengthened classroom blocks at 36 schools across the Everest region to replace those damaged and destroyed in the earthquakes.\nMonjo students are some of over 7000 children that are now able to study in safe, strong classrooms. And their families and communities will benefit from these facilities for decades to come.";
                    break;
                case "SagarmathaNationalPark":
                    source = "SagarmathaNationalPark.png";
                    projectName = "Sagarmatha National Park";
                    details = "In 1979, with the backing of Sir Edmund Hillary and the New Zealand government, the Sagarmatha National Park Forestry Project is established to promote the sustainable management of the forests in the region and to minimise damage to the forests from an increase in the local population and tourist visitors. The park is now a World Heritage Site and encompasses an area of 1,148 km2.\n\nIn the 1970s, rangers from New Zealand’s National Park Service went over to Nepal to help manage the park, and Nepali forest rangers came over to New Zealand to undertake training in sustainable forest management.";
                    break;
                case "TheYetiScalp":
                    source = "TheYetiScalp.png";
                    projectName = "The yeti scalp";
                    details = "In 1960, Ed returned to the Everest region to lead an expedition with two very different goals:\n1. To learn more about what happens to the human body at high altitude where there is less\noxygen in the air, and\n2. To search for legendary Yeti or Abominable Snowman that is believed to live in the\nHimalayan Mountains. \nEd’s took what was thought to be Yeti skin and a scalp from the Himalayas to America, France and England for further investigation. \n\nScientists believed the scalp was in fact shaped from the skin of a serow, and what was thought to be a Yeti skin was in fact skin from a Tibetan blue bear.\n\nEd’s team was never able to find out for sure whether the Himalayan Yeti exists. Many people believe the Yeti still lives in hiding high above where any human can live.\n\nWhilst Ed didn’t catch a Yeti, he did discover\nsomething unexpected that would keep him busy for the rest of his life. It was during this expedition that Ed asked his Sherpa friends what he could do to repay them for their friendship and support. They asked for his help building a school in Khumjung. And so he did. Ed went on to devote much of his life from then on to helping the people of the Everest region.\n\nThe yeti scalp is on display at the Khumjung Gompa.";
                    break;
                case "EverestAvalanche":

                    projectName = "Everest avalanche on Popcorn Field";
                    details = "In April 2014, 16 families lost their fathers, sons and husbands in a devastating avalanche on the slopes of Everest. Many of the climbers killed in the avalanche were from the upper Khumbu area, where the Himalayan Trust has been working for 60 years. Immediately following news of the avalanche, an appeal was launched to help the families. Since that tragic day, we have supported the families of those who were killed by providing scholarships for their school-age children.";
                    break;
                case "KhumjungWater":

                    projectName = "Khumjung water project";
                    details = "In 1963, Sir Edmund Hillary's HImalayan Trust builds its first water supply system in the village of Khumjung. The water system is such an immediate and dramatic help to the community, it causes tears of joy as the first water gushes out of the pipe.";
                    break;
                case "TengbocheMonastery":

                    projectName = "Tengboche Monastery";
                    details = "In 1993, the Himalayan Trust helped rebuild Tengboche Monastery after it was destroyed in a fire. Most Everest expeditions, including the 1953 expedition, stop at Tengboche Monastery to be blessed on their way to the mountain.";
                    break;
                case "PhortseSchool":
                   
                    projectName = "Phortse school";
                    details = "Monjo school is one of 60 across the region that the Himalayan Trust supports with vital equipment, resources and training for teachers.\n\nThe Himalayan Trust also built the new earthquake-strengthened classroom block.\n\nFollowing the devastating earthquakes in 2015, the Himalayan Trust developed its biggest ever school building project. With funding from the New Zealand public, we built 150 earthquake-strengthened classroom blocks at 36 schools across the Everest region to replace those damaged and destroyed in the earthquakes.\n\nPhortse students are some of over 7000 children that are now able to study in safe, strong classrooms. And their families and communities will benefit from these facilities for decades to come.";
                    break;

            }
            images.Source = source;
            names.Text = projectName;
            description.Text = details;
        }
    }
}
