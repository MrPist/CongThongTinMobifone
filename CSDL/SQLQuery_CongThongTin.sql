use CongThongTinMobifone

-- Dữ liệu bảng dạng số điện thoại (Number_Type)
INSERT INTO Number_Type(Number_TypeID,Title, Content) VALUES(N'NT001',N'Sim Phong Thủy',N'Những con số mang giá trị tương trợ cho những cung mệnh hữu.');
INSERT INTO Number_Type(Number_TypeID,Title,Content) VALUES(N'NT002',N'Sim Tài Lộc',N' Đặc điểm là số cuối hoặc cặp trùng lặp mang giá ý nghĩa may mắn, thu hút tài lộc cho người sở hữu');
INSERT INTO Number_Type(Number_TypeID,Title,Content) VALUES(N'NT003',N'Sim thần tài',N'Một loại sim được mọi người săn lùng và càng trở nên hiếm. Với các số cuối hoặc cặp trùng lặp là 39 - thần tài nhỏ hoặc 79 - thần tài lớn');
INSERT INTO Number_Type(Number_TypeID,Title,Content) VALUES(N'NT004',N'Sim lặp',N'--AABBCC, ABABAB-- Một dãy số vô cùng khang hiếm do số lượng đã ít mà còn được giới sành sỏi đánh giá rất cao và sẵn sàng trả phí cao để sở hữu.');
INSERT INTO Number_Type(Number_TypeID,Title,Content) VALUES(N'NT005',N'Sim tiến đều',N'--ABCDE-- Sảnh tiến. Loại sim này đã thành công trong việc thuyết phục những người dùng khó tính đến đâu cũng phải siêu lòng.');
INSERT INTO Number_Type(Number_TypeID,Title,Content) VALUES(N'NT006',N'Sim tứ quý',N'--AAAA-- Một loại sim mà chỉ cần xuất hiện thôi thì chi phí để sở hữu đã không còn là vấn đề nữa');
select * from Number_Type

-- Dữ liệu bảng Loại bài đăng (Post_Cate)
INSERT INTO Post_cate (PostCateID,Name, Description) VALUES (N'PCT1',N'Trang tin tức',N'Tổng hợp các bài viết, tin tức của website.');
INSERT INTO Post_cate(PostCateID,Name,Description) VALUES (N'PCT2',N'Trang gói cước',N'Bao gồm các thông tin về gói cước data cũng như là cước gọi.');
INSERT INTO Post_cate(PostCateID,Name,Description) VALUES (N'PCT3',N'Trang sim số',N'Nơi tổng hợp các loại sim số với đa dạng hình thức cho người dùng lựa chọn.');
select * from Post_cate

-- Dữ liệu bảng số điện thoại (Phone_number)
INSERT INTO Phone_number(Number, Number_TypeID, PostCateID, description) VALUES(N'0796524139',N'NT003',N'PCT3',N'Với đuôi 39 - thần tài nhỏ thì chủ sở hữu sẽ gặp được rất nhiều may mắn trong công việc cũng như cuộc sống');
INSERT INTO Phone_number(Number, Number_TypeID, PostCateID, description) VALUES(N'0792323592',N'NT004',N'PCT3',N'Với phong cách lặp số ở giữa tạo sự khác biệt và ấn tượng cho người sở hữu');
INSERT INTO Phone_number(Number, Number_TypeID, PostCateID, description) VALUES(N'0919323456',N'NT005',N'PCT3',N'Sảnh tiến công việc thăng tiến');
INSERT INTO Phone_number(Number, Number_TypeID, PostCateID, description) VALUES(N'0923954079',N'NT003',N'PCT3',N'Thần tài lớn mang theo niềm vui lớn');
INSERT INTO Phone_number(Number,Number_TypeID, PostCateID, description) VALUES(N'0793928888',N'NT006',N'PCT3',N'Tứ quý 8 mang lại sự nghiệp thăng tiến và sự hưng thịnh trường tồn mãi mãi');
select * from Phone_number

-- Dữ liệu bảng gói cước (Package)
INSERT INTO Package (Package_ID, Package_title, Package_content, Package_Cate, PostCateID, description) VALUES (N'',N'',N'',N'',N'',N'');

-- Dữ liệu bảng trang tin (Post)
INSERT INTO Post (PostID, Post_title, Post_content, PostCateID, Date_created, Date_update, avatar, active) VALUES (N'P001',N'Mình cùng đón Giáp Thìn - 2024',N'Từ ngày 12/12/2023 đến ngày 31/01/2024, MobiFone Tỉnh An Giang triển khai chương trình khuyến mại “Mình cùng đón Giáp Thìn – 2024!” Khách hàng hòa mạng mới hoặc đăng ký mới/gia hạn bất kỳ gói cước Data nào của MobiFone trong thời gian diễn ra chương trình .

																															Chào đón Năm Mới Giáp Thìn 2024, MobiFone An Giang triển khai chương trình khuyến mại “Mình Cùng Đón Giáp Thìn 2024! ” từ ngày 12/12/2023 đến 31/01/2024 Khách hàng hòa mạng mới hoặc đăng ký mới/gia hạn bất kỳ gói cước Data nào của MobiFone trong thời gian diễn ra chương trình, như một lời chúc, một lời tri ân sâu sắc dành cho các khách hàng đã luôn tin yêu và đồng hành cùng MobiFone Tỉnh An Giang.

																															Theo đó, từ ngày từ ngày 12/12/2023 đến 31/01/2024, Khách hàng hòa mạng mới hoặc đăng ký mới/gia hạn bất kỳ gói cước data nào của MobiFone trong thời gian diễn ra chương trình có nhắn tin sms tới số thuê bao 0779249999 kèm số dự đoán gần đúng nhất của 03 số cuối kết quả Giải đặc biệt Xổ số Kiến thiết tỉnh An Giang xổ ngày 01/02/2024.

																															Ví dụ: Thuê bao phát triển mới ngày 15/12/2023 soạn tin nhắn: 678 gởi đến 0779249999.

																															Sau khi nhắn tin tham gia chương trình thành công, khách hàng sẽ nhận lại được tin nhắn xác nhận đã đăng ký thành công – chậm nhất ngày n+1
																															Mỗi khách hàng chỉ được tham dự 01 mã dự thưởng cho 1 số thuê bao (gồm thuê bao trả trước hoặc thuê bao trả sau)
																															Kết quả trúng thưởng được căn cứ vào dự đoán của khách hàng có số gần đúng với 03 số cuối (trường hợp giống kết quả sẽ xét thời gian sớm hơn) của Giải đặc biết Xổ số Kiến thiết tỉnh An Giang ngày 01/02/2024
																															Giải thưởng:
																																1 giải nhất: 1 chỉ vàng 9999.
																																20 giải nhì: thẻ cào mệnh giá 100.000đ.
																																24 giải ba: thẻ cào mệnh giá 50.000đ.
																																100 giải khuyến khích: 1 hộp khẩu trang y tế.'
,N'PCT1','03/20/2024','03/20/2024','~~\images\Post_avt\GIAPTHINH_2.jpg',0);
select * from Post

